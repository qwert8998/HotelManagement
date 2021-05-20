import { Injectable } from '@angular/core';
import { ApiServiceService } from './api-service.service';
import { Observable } from 'rxjs';
import { roomtypedetail } from 'src/app/shared/roomtype';
import { roomtyperes } from 'src/app/shared/response/roomtyperes';

@Injectable({
  providedIn: 'root'
})
export class RoomtypeService {

  constructor(private apiService: ApiServiceService) { }

  getAllRoomType(): Observable<roomtypedetail[]>
  {
    return this.apiService.getList('RoomType/GetAllRoomTypes');
  }

  getRoomTypeById(id: number): Observable<roomtyperes>
  {
    return this.apiService.getOne('RoomType/GetById/?id=' + id);
  } 

  updateRoomType(resource: any): Observable<roomtyperes>
  {
    return this.apiService.update('RoomType/UpdateRoomType', resource);
  }
}
