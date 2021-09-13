import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Routes } from '@angular/router';



@Component({
  selector: 'app-show-movies',
  templateUrl: './show-movies.component.html',

})



export class ShowMoviesComponent {
  public movies: Movie[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.route.params.subscribe(params => http.get<Movie[]>(baseUrl + 'api/movies/' + params['id']).subscribe(result => {
      this.movies = result;

    }, error => console.error(error)));

  }

}

interface stills {
  id: number;
  movieid: number;
  stillurl: string;
}

interface Movie {
  id: number;
  title: string;
  language: string;
  location: string;
  plot: string;
  poster: string;
  soundeffects: string;
  imdbid: string;
  listingtype: number;
  imdbrating: number;
  stills: stills[];
}

