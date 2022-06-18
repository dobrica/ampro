import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Template } from './model/template.model';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  numberOfChars = 150;
  templatesServiceBaseUrl = "http://172.23.0.6";
  getAllTemplatesEndpoint = "/api/TextTemplates/getall";
  wordsCount: number = 0;
  distinctWordsCount: number = 0;
  mostFreqWord: string = "word";
  charactersCount: number = 0;

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

  getTemplates(): void {
    this.httpClient.get(this.templatesServiceBaseUrl.concat(this.getAllTemplatesEndpoint)).subscribe(
      (response: any) => {
        for (let entry of response) {
          var template = new Template();
          template.primaryId = Number(entry.primaryId);
          template.body = String(entry.body);
          console.log(template);
          this.templates.push(template);
        }
      });
  }

  text(text: string) {
    console.log("clicked" + text);
  }

  public message(): void {
    console.log(
      this.messageForm.controls.email.value,
      this.messageForm.controls.messageBody.value,
    );
  }

  upload(): void {
    
  }

}
