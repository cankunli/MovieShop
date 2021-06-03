import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Genre } from 'src/app/shared/models/genre';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private apiService: ApiService) { }

  getAllGenres() : Observable<Genre[]>{
    //https://localhost:44336/api/Genres
    return this.apiService.getAll('genres');
  }
}
