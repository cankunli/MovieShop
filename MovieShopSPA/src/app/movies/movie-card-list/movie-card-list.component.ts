import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  genreMovies: MovieCard[] | undefined;
  constructor(private movieService: MovieService,private route:ActivatedRoute) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.params['id']);
    this.movieService.getMoviesByGenre(id).subscribe(
      m => {
        this.genreMovies = m;
        console.table(this.genreMovies);
      }
    )
  }

}
