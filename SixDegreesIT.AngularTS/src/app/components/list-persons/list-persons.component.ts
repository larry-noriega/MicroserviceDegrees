import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { Person } from 'src/app/interfaces/person';
import { PersonService } from 'src/app/services/get-person.service';

@Component({
  selector: 'app-list-persons',
  templateUrl: './list-persons.component.html',
  styleUrls: ['./list-persons.component.css']
})
export class ListPersonsComponent implements OnInit {
  public persons?: Person[] = [];

  constructor(private _personService: PersonService) { }

  ngOnInit(): void {
    this.getPersons();
  }

  getPersons() {
    this._personService.getListComentarios().subscribe({
      next: (data) => this.persons = data,
      error: (err) => console.error(err)
    });
  }

  // constructor(http: HttpClient) {
  //   http.get<Person[]>('/api/persons').subscribe(result => {
  //     this.persons = result;
  //   }, error => console.error(error));
  // }

}
