import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CastService } from 'src/app/core/services/cast.service';
import { Cast } from '../../models/cast';

@Component({
  selector: 'app-cast',
  templateUrl: './cast.component.html',
  styleUrls: ['./cast.component.css']
})
export class CastComponent implements OnInit {

  castDetails!: Cast;
  constructor(private castService: CastService, private route:ActivatedRoute) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.params['id']);
    this.castService.getCastDetail(id).subscribe(
      m => {
        this.castDetails = m;
        console.table(this.castDetails);
      }
    )
  }

}
