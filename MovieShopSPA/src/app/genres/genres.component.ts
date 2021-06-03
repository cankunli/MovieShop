import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service';
import { Genre } from '../shared/models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genres: Genre[] | undefined;

  constructor(private GenreService: GenreService) { }

  ngOnInit(): void {

    this.GenreService.getAllGenres().subscribe(g=>{
      this.genres = g;
      console.log(this.genres);
    })
  }

}
