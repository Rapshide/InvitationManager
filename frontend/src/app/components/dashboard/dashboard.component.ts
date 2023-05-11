import { Component, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

export interface TimeType {
  id: string;
  title: string;
  startDate: Date;
  endDate: Date;
  description: string;
  allDay: boolean;
}

const ELEMENT_DATA: TimeType[] = [
  {id: '1', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '2', title: 'Kövér cickány1', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '3', title: 'Kövér cickány2', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '4', title: 'Kövér cickány3', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '5', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '6', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '7', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '8', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '9', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
  {id: '10', title: 'Kövér cickány', description: 'Szia uram!', allDay: false, endDate: new Date(), startDate: new Date()},
];

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  constructor(private readonly router: Router){}

  @ViewChild('table', { read: ElementRef }) table!: ElementRef<HTMLInputElement>;
  displayedColumns: string[] = ['title', 'startDate', 'endDate', 'description', 'allDay', 'button'];
  dataSource = ELEMENT_DATA;


  editTime(id: string): void {
    this.router.navigate(['/', 'dashboard', 'edit', `${id}`]);
  }
}
