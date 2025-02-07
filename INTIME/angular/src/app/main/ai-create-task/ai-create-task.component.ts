import { Component, OnInit } from '@angular/core';
import { AIHackathonServiceProxy, TaskItem } from '@shared/service-proxies/service-proxies';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';

@Component({
  selector: 'app-ai-create-task',
  templateUrl: './ai-create-task.component.html',
  styleUrls: ['./ai-create-task.component.css']
})
export class AiCreateTaskComponent implements OnInit {

  constructor(public service:AIHackathonServiceProxy) { }
  taskTitle:string;
  taskItem=new TaskItem();
  taskDescription:string;
  ngOnInit() {
this.getTasks();
  }

  getTasks(){
  this.service.getTasks().subscribe((result)=>{
    console.log(result);
    this.taskTitle = result[0].title;
    this.taskItem = result[0];
  } );
}

getProjects(){
  this.service.getProjects().subscribe((result)=>{
    console.log(result);
  });
}

getProjectTasks(){
  this.service.getProjectTasks().subscribe((result)=>{
    console.log(result);
  });
}

createTask(){
  debugger;
  this.service.createDescriptionPrompt(this.taskItem).subscribe((result)=>{
    console.log('create task',result);
    this.taskDescription=result.description;
  });
}


}
