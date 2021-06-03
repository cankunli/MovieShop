import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { MovieDetails } from 'src/app/shared/models/movie-details';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTop30GrossingMovies():Observable<MovieCard[]>{
    return this.apiService.getAll('movies/toprevenue');
  }

  getMovieDetails(id: number):Observable<MovieDetails>{
    return this.apiService.getOne('movies/', id);
  }

  getMoviesByGenre(genreId: number): Observable<MovieCard[]> {
    return this.apiService.getAll('Movies/genre/' + genreId);
  }
}

