import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-find-atms',
  templateUrl: './find-atms.component.html'
})
export class FindAtmsComponent {
  public geographicCoordinates: GeographicCoordinates[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<GeographicCoordinates[]>(baseUrl + 'api/Atms/GetAtmsGeographicCoordinatesAsync').subscribe(result => {
      this.geographicCoordinates = result;
    }, error => console.error(error));
  }
}

interface GeographicCoordinates {
  latitude: string;
  longitude: string;
}
