import { MovieCard } from "./movie-card";

export interface Cast {
    id: number;
    name: string;
    gender: string;
    tmdbUrl: string;
    profilePath: string;
    character: string;
    movies: MovieCard[];
}