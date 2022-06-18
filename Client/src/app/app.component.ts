import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  templatesServiceBaseUrl = "http://172.23.0.6";
  getAllTemplatesEndpoint = "/api/TextTemplates/getall";

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getTemplates();
  }

  getTemplates() {
    this.httpClient.get(this.templatesServiceBaseUrl.concat(this.getAllTemplatesEndpoint)).subscribe(data => {
      console.log(data);  
    });
  }

}
