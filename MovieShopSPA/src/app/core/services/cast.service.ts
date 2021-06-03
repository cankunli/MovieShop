import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cast } from 'src/app/shared/models/cast';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CastService {

  constructor(private apiService: ApiService) { }

  getCastDetail(id: number):Observable<Cast>{
    return this.apiService.getOne('cast/', id);
  }
}
