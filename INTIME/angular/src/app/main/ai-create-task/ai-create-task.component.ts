import { Component, OnInit } from '@angular/core';
import { AIHackathonServiceProxy, Project, ProjectTask, TaskItem } from '@shared/service-proxies/service-proxies';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';

@Component({
    selector: 'app-ai-create-task',
    templateUrl: './ai-create-task.component.html',
    styleUrls: ['./ai-create-task.component.css']
})
export class AiCreateTaskComponent implements OnInit {

    constructor(public service: AIHackathonServiceProxy) { }
    taskTitle: string;
    taskItem = new TaskItem();
    taskDescription: string;
    projects: any[];
    projectTask: ProjectTask[];
    selectedProject: string = '';
    selectedProjecttitle: string = '';

    ngOnInit() {
        this.getProjects();
        //this.getTasks();
    }

    getTasks() {
        this.service.getTasks().subscribe((result) => {
            console.log(result);
            this.taskTitle = result[0].title;
            this.taskItem = result[0];
        });
    }

    getProjects() {
        this.service.getProjects().subscribe((result) => {
            console.log(result);
            this.projects = result;
        });
    }

    getProjectTasks(projectId) {
        this.service.getProjectTasks(projectId).subscribe((result) => {
            this.projectTask = result;
           
            console.log(result);
        });
    }

    createTask() {
        debugger;
        this.service.createDescriptionPrompt(this.taskItem).subscribe((result) => {
            console.log('create task', result);
            this.taskDescription = result.description;
        });
    }
    onProjectTaskSelect(event) {
       
        let project = this.projectTask.filter(x => x.id == event.target.value);
        this.taskItem = new TaskItem();
        this.taskItem.id = project[0].id;
        this.taskItem.title = project[0].title;

        this.createTask()
    }
    onProjectSelect(event: any) {
        const projectId = event.target.value;
        if (projectId) {
            this.getProjectTasks(projectId);
        }
    }


}
