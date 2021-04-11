import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  movies: Array<any> = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getMovies().subscribe(data => {
      for (let object of Object.values(data)) {
        this.movies.push(object);
      }
      console.log(this.movies);
    })
  }
}
