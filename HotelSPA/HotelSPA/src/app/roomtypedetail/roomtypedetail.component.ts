import { Component, OnInit } from '@angular/core';
import { RoomtypeService } from '../core/services/roomtype.service';
import { Router, ActivatedRoute } from '@angular/router';
import { roomtyperes } from '../shared/response/roomtyperes';

@Component({
  selector: 'app-roomtypedetail',
  templateUrl: './roomtypedetail.component.html',
  styleUrls: ['./roomtypedetail.component.css']
})
export class RoomtypedetailComponent implements OnInit {

  typedetail!: roomtyperes;
  id!: number;

  constructor(private typeService: RoomtypeService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params => {
        this.id = params.get('id') ? Number(params.get('id')) : 0;
        console.log(this.id);
        this.typeService.getRoomTypeById(this.id).subscribe(m => {
          this.typedetail = m;
          console.table(this.typedetail);
        });
      }
    );
  }

  Update()
  {
    let update =JSON.parse(JSON.stringify(this.typedetail.roomType));
    console.log(update);
    this.typeService.updateRoomType(update).subscribe(response =>{
      if(response.message == "Success")
      {
        this.router.navigate(['/roomtype']);
      }
      else
      {
        console.log(response.message);
      }
    });

  }

}
