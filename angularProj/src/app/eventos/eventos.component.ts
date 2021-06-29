import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})

export class EventosComponent implements OnInit {

  _filtroLista: string | undefined;

  get filtroLista(): any {
    return this._filtroLista;
  } 

  set filtroLista( value: string){
    this._filtroLista = value;
    this.eventos = !this.filtroLista ? this.getEventos() : this.filtraEvento(this.filtroLista);
  }

 
  eventos: any = [];
  imageWidth: number = 50;
  imageHeigth: number = 2;
  mostrarImg = false;
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  filtraEvento(searchWord: string): any{
    searchWord = searchWord.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(searchWord) !== -1
    );
  }

  api(){
    return "http://localhost:5000/api/values";
  }

  showImg(){
    this.mostrarImg = !this.mostrarImg;
  }

  getEventos(){
    this.eventos = this.http.get(this.api()).subscribe(
      response  => {
        this.eventos = response;
      }, error => {
        console.log(error);
      }
    );
  }

}
