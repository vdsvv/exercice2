import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private serviceUrl : string
   
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private http :HttpClient) {
    this.serviceUrl = environment.apiUrl + "users"
  }
  
  getUsers(): Observable<User[]> {
      var users = this.http.get<User[]>(this.serviceUrl);
      return users
  }

  getUser(userId: number): Observable<User> {
    var url = `${this.serviceUrl}/${userId}`
    var entity = this.http.get<User>(url, this.httpOptions)
    return entity
  }

  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.serviceUrl, user, this.httpOptions)
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<User>(this.serviceUrl + `/${user.id}`, user, this.httpOptions)
  }

  deleteUser(user: User): Observable<any> {
    return this.http.delete(this.serviceUrl + `/${user.id}`, this.httpOptions)
  }
}
