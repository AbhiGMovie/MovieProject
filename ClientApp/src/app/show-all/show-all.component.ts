import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-show-all',
  templateUrl: './show-all.component.html'
})

export class ShowAllMoviesComponent {
  public booleanValue: any = false;
  public search: string = "";
  public filterlocation: string = "";
  public filterlanguage: string = "";
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
    this.showmovies = this.movies;
    if (id == "ddlocation") {
      if (val == "ALL")
        this.filterlocation = "";
      else
        this.filterlocation = val;           
    }
    else {
      if (val == "ALL")
        this.filterlanguage = "";
      else
        this.filterlanguage = val;      
    }
    if (this.filterlocation != "")
      this.showmovies = this.showmovies.filter(x => x.location === this.filterlocation);
    if (this.filterlanguage != "")
      this.showmovies = this.showmovies.filter(x => x.language === this.filterlanguage);
  }
  public searchMovies() {
    var val = this.search.toLowerCase();
    this.showmovies = this.movies;
    if (this.filterlocation !== "")
      this.showmovies = this.showmovies.filter(x => x.location === this.filterlocation);
    if (this.filterlanguage !== "")
      this.showmovies = this.showmovies.filter(x => x.language === this.filterlanguage);
    if(val != "")
      this.showmovies = this.showmovies.filter(x => x.location.toLowerCase().includes(val) || x.language.toLowerCase().includes(val) || x.title.toLowerCase().includes(val) || x.imdbRating.toString().includes(val));
    
  }
  public sortFunction(colName, boolean, event) {
    var id = event.target.id;
    var button = document.getElementById(id);
    
    if (boolean == true) {
      this.showmovies = this.showmovies.sort((a, b) => a[colName] < b[colName] ? 1 : a[colName] > b[colName] ? -1 : 0)
      this.booleanValue = !this.booleanValue;
      button.className = "fa fa-arrow-down";
    }
    else {
      this.showmovies = this.showmovies.sort((a, b) => a[colName] > b[colName] ? 1 : a[colName] < b[colName] ? -1 : 0)
      this.booleanValue = !this.booleanValue;
      button.className = "fa fa-arrow-up";
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
  soundeffects: string;
  imdbID: string;
  listingtype: number;
  imdbRating: number;
}
