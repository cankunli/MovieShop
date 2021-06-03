import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { MovieDetails } from 'src/app/shared/models/movie-details';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movieDetails!: MovieDetails;
  
  constructor(private movieService: MovieService, private route:ActivatedRoute) { }
  

  ngOnInit(){
    const id = Number(this.route.snapshot.params['id']);
    this.movieService.getMovieDetails(id).subscribe(
      m => {
        this.movieDetails = m;
        console.table(this.movieDetails);
      }
    )
  }
}
