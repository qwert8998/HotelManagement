import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { RoomComponent } from './room/room.component';
import { ServiceComponent } from './service/service.component';
import { RoomTypeComponent } from './room-type/room-type.component';
import { RoomdetailComponent } from './roomdetail/roomdetail.component';
import { RoomtypedetailComponent } from './roomtypedetail/roomtypedetail.component';
import { ServiComponent } from './servi/servi.component';
import { CustdetailComponent } from './custdetail/custdetail.component';

const routes: Routes = [
  { path: "customer", component: CustomerComponent },
  { path: "room", component: RoomComponent },
  { path: "service", component:ServiceComponent },
  { path: "roomtype", component: RoomTypeComponent },
  { path: "roomtype/:id", component: RoomtypedetailComponent },
  { path: "room/:id", component: RoomdetailComponent },
  { path: "serv/:id", component: ServiComponent },
  { path: "cust/:id", component: CustdetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
