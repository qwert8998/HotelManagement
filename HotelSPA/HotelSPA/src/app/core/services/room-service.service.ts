import { Injectable } from '@angular/core';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root'
})
export class RoomServiceService {

  constructor(private apiService: ApiServiceService) { }
}
