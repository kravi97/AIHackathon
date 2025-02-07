using Abp.Domain.Repositories;
using INTIME.AI;
using Microsoft.AspNetCore.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace INTIME.AIHackathon
{
    public class AIHackathonAppService : INTIMEAppServiceBase
    {

        private static readonly HttpClient client = new HttpClient();
        //private static readonly string aiApiUrl = "https://futureframe-openai.openai.azure.com/openai/deployments/gpt-4o-mini/chat/completions?api-version=2023-05-15";
        //private static readonly string aiApiKey = "46QdSqnoge6wQdGh49rdqXMK9bxbo2AOq1rWOvwZhNpAG6DRg4cXJQQJ99BAACYeBjFXJ3w3AAABACOGfqhk"; // Replace with your actual API Key
        //private static string clientId = "e87446ee-95ce-4891-a7b1-89000d338182";
        private readonly IRepository<Project, Guid> _projectRepository;
        private readonly IRepository<ProjectTask, Guid> _projectTaskRepository;
        private static readonly string aiApiUrl = "";
        private static readonly string aiApiKey = ""; // Replace with your actual API Key
        private static string clientId = "";

        public AIHackathonAppService(IRepository<ProjectTask, Guid> projectTaskRepository, IRepository<Project, Guid> projectRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectRepository = projectRepository;

        }

        public class TaskItem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Status { get; set; }
        }
        public class TaskItemDetails
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }
        public async Task<List<TaskItem>> GetTasksAsync()
        {
            try
            {
                List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem { Id = "1", Title = "Bug: Surgeries Primary provider is not showing in record when its role is changed.", Status = "Completed" }
            };
                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tasks: {ex.Message}");
                return new List<TaskItem>();
            }
        }
        public async Task<TaskItemDetails> CreateDescriptionPrompt(TaskItem task)
        {
            // Ask the AI to return the title and description in a structured JSON format
            string prompt = $"Generate a detailed description for the following task in JSON format with only 'Title' and 'Description' fields:\nTask ID: {task.Id}\nTitle: {task.Title}\nStatus: {task.Status}";
            return await GetAIDescription(prompt);
        }
        public async Task<TaskItemDetails> GetAIDescription(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[] { new { role = "user", content = prompt } },
                max_tokens = 300 // Increase the tokens if the response needs to be larger
            }; client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", aiApiKey);
            client.DefaultRequestHeaders.Add("api-key", aiApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); try
            {
                var response = await client.PostAsJsonAsync(aiApiUrl, requestBody);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(jsonResponse);                // This assumes the AI returns a well-formed JSON object for Title and Description
                var aiGeneratedText = json.choices[0].message.content.ToString().Trim();
                aiGeneratedText = aiGeneratedText.Replace("```json", "").Replace("```", "").Trim();
                TaskItemDetails generatedTask = JsonConvert.DeserializeObject<TaskItemDetails>(aiGeneratedText);                // Parse the AI response as JSON into TaskItem object
                return generatedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating AI description: {ex.Message}");
                return null;
            }
        }

        public OnlineMeeting AddMeetingParticipants(
   OnlineMeeting onlineMeeting, List<string> attendees)
        {
            var meetingAttendees = new List<MeetingParticipantInfo>();
            foreach (var attendee in attendees)
            {
                if (!string.IsNullOrEmpty(attendee))
                {
                    meetingAttendees.Add(new MeetingParticipantInfo
                    {
                        Upn = attendee.Trim()
                    });
                }
            }
            if (onlineMeeting.Participants == null)
            {
                onlineMeeting.Participants = new MeetingParticipants();
            };
            onlineMeeting.Participants.Attendees = meetingAttendees;
            return onlineMeeting;
        }
        public async Task ScheduleTeamsMeetingAsync(string title, DateTimeOffset startTime, DateTimeOffset endTime, List<string> participants)
        {
            try
            {
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithClientSecret("81w8Q~1JNmILphs6ZqKl8EZZARmW7HPdTAnWGc0T")
                   .WithAuthority(new Uri("https://login.microsoftonline.com/2dfa4a9c-946e-481a-8a37-6817cebd08ac/oauth2/v2.0/token"))
                .Build();
                var scopes = new[] { "https://graph.microsoft.com/.default" };
                var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(
                        (requestMessage) =>
                        {
                            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
                            return Task.FromResult(0);
                        }));
                // Define an online meeting object
                var onlineMeeting = new OnlineMeeting
                {
                    StartDateTime = startTime,
                    EndDateTime = endTime,
                    Subject = title,
                    AllowedPresenters = OnlineMeetingPresenters.Everyone,
                    Participants = new MeetingParticipants
                    {
                        Organizer = new MeetingParticipantInfo
                        {
                            Identity = new IdentitySet
                            {
                                User = new Microsoft.Graph.Identity { Id = "bd545b99-62a0-4057-a4fe-0c4493a7024f" }
                            }
                        },
                    }
                };
                onlineMeeting = AddMeetingParticipants(onlineMeeting, participants);

                var user = await graphClient.Users.Request()
                    .Filter($"userPrincipalName eq 'dhanashri.patil@waiin.com'")
                    .GetAsync();
                var userId = "9af1c75e-92fb-48ae-92e6-7310012d1a96";
                // Create the online meeting
                var meetingGuid = Guid.NewGuid();
                var createMeetingResponse = await graphClient.Users[userId].OnlineMeetings
         .CreateOrGet(meetingGuid.ToString(), null, endTime, onlineMeeting.Participants, startTime, "Daily Schedule")
         .Request()
         .PostAsync();
                Console.WriteLine($"Meeting created successfully. Join URL: {createMeetingResponse.JoinWebUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating meeting: {ex.Message}");
            }
        }
    
        public async Task<List<ProjectTask>> GetProjectTasksAsync(Guid projectId)
        {
            try
            {
                var tasks = await _projectTaskRepository.GetAllListAsync(xx=>xx.ProjectId==projectId);
                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tasks: {ex.Message}");
                return new List<ProjectTask>();
            }
        }

        public async Task<ProjectTask> CreateProjectTaskAsync(ProjectTask task)
        {
            try
            {
                var newTask = await _projectTaskRepository.InsertAsync(task);
                return newTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating task: {ex.Message}");
                return null;
            }
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            try
            {
                var newProject = await _projectRepository.InsertAsync(project);
                return newProject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating project: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            try
            {
                var aa = _projectRepository.GetAll();
                var tasks = await _projectRepository.GetAllListAsync();
                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tasks: {ex.Message}");
                return new List<Project>();
            }
        }

    }
}

