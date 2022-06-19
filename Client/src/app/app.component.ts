import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Template } from './model/template.model';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageStatsRequest } from './model/message-stats-request.model';
import { AddMessageRequest } from './model/add-message-request.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  timeout: any = null;
  numberOfChars = 150;
  templatesServiceBaseUrl = "http://172.23.0.6";
  messagesServiceBaseUrl = "http://172.23.0.4";
  textStatisticsServiceBaseUrl = "http://172.23.0.7";
  getAllTemplatesEndpoint = "/api/TextTemplates/getall";
  getMessageStatsEndpoint = "/api/textstatistics/message/stats";
  addNewMessageEndpoint = "/api/messages/add";
  wordsCount: number = 0;
  distinctWordsCount: number = 0;
  mostFreqWord: string = "word";
  charactersCount: number = 0;

  currentMessage: string | undefined;
  file!: File;

  templates: Array<Template> = [];

  public messageForm = new FormGroup({
    email: new FormControl(''),
    messageBody: new FormControl(''),
  });

  public uploadFileForm = new FormGroup({
    file: new FormControl(''),
  });

  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {
    this.getTemplates();
  }

  public getTemplates(): void {
    this.httpClient.get(this.templatesServiceBaseUrl.concat(this.getAllTemplatesEndpoint)).subscribe(
      (response: any) => {
        for (let entry of response) {
          var template = new Template();
          template.primaryId = Number(entry.primaryId);
          template.body = String(entry.body);
          this.templates.push(template);
        }
      });
  }

  public updateTemplate(text: string) {
    this.messageForm.controls.messageBody.setValue(text);
    this.updateStats();
  }

  public message(): void {
    var request = new AddMessageRequest();
    request.from = this.messageForm.controls.email.value ?? "";
    request.body = this.messageForm.controls.messageBody.value ?? "";
    this.httpClient.post(this.messagesServiceBaseUrl.concat(this.addNewMessageEndpoint), request).subscribe(
      (response: any) => {
        alert("Your message was sent successfully!")
      });
  }

  public upload(event: any) {
    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsText(this.file);
    fileReader.onload = () => {
      var text = fileReader.result?.toString() ?? "";
      this.updateTemplate(text);
    }
  }

  public updateStats(): void {
    clearTimeout(this.timeout);
    this.timeout = setTimeout(() => {
      this.getMessageStats();
    }, 500);
  }

  public getMessageStats() {
    var request = new MessageStatsRequest();
    request.from = this.messageForm.controls.email.value ?? "";
    request.body = this.messageForm.controls.messageBody.value ?? "";
    this.httpClient.post(this.textStatisticsServiceBaseUrl.concat(this.getMessageStatsEndpoint), request).subscribe(
      (response: any) => {
        this.wordsCount = response.wordsCount;
        this.distinctWordsCount = response.distinctWordsCount;
        this.mostFreqWord = response.mostFreqWord;
        this.charactersCount = response.charactersCount;
      });
  }

}
