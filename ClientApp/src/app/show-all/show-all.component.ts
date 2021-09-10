import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-show-all',
  templateUrl: './show-all.component.html'
})

export class ShowAllMoviesComponent {
  public booleanValue: any = false;
  public movies: Movie[];
  public uniquelanguage: string[];
  public uniquelocation: string[];
  public showmovies: Movie[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie[]>(baseUrl + 'api/movies').subscribe(result => {
      this.movies = result;
      this.showmovies = result;
      this.uniquelanguage = Array.from(new Set(this.movies.map(x => x.language)));
      this.uniquelocation = Array.from(new Set(this.movies.map(x => x.location)));
      this.uniquelanguage.splice(0, 0, "ALL");
      this.uniquelocation.splice(0, 0, "ALL");
    }, error => console.error(error));
  }
  public onoptionChanged(event) {
    var val = event.target.value;
    var id = event.target.id;
    if (event.target.value === "ALL")
      this.showmovies = this.movies;
    else {
      if (id == "ddlocation") {
        this.showmovies = this.movies.filter(x => x.location === val);
      }
      else {
        this.showmovies = this.movies.filter(x => x.language === val);
      }
    }
  }
  public sortFunction(colName, boolean) {
    if (boolean == true) {
      this.showmovies.sort((a, b) => a[colName] < b[colName] ? 1 : a[colName] > b[colName] ? -1 : 0)
      this.booleanValue = !this.booleanValue
    }
    else {
      this.showmovies.sort((a, b) => a[colName] > b[colName] ? 1 : a[colName] < b[colName] ? -1 : 0)
      this.booleanValue = !this.booleanValue
    }
  }
}

 




interface Movie {
  Id: number;
  title: string;
  language: string;
  location: string;
  Plot: string;
  Poster: string;
  SoundEffects: string;
  imdbID: string;
  listingType: number;
  imdbRating: number;
}
