import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpStatusCode
} from '@angular/common/http';
import { catchError, EMPTY, finalize, Observable, share } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/services/shared-service/shared.service';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  private apiBaseUrl = environment.apiBaseUrl;
  private pendingRequests: Map<string, Observable<HttpEvent<any>>> = new Map();

  constructor(private toastr: ToastrService,
    private sharedService: SharedService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const bearerToken = this.sharedService.getToken();

    let apiRequest = request.clone({
      url: `${this.apiBaseUrl}/${request.url}`
    });

    if(bearerToken){
      apiRequest = apiRequest.clone({
        setHeaders: {
          Authorization: `Bearer ${bearerToken}`
        }
      })
    }

    const requestUrl = apiRequest.url;

    if (this.pendingRequests.has(requestUrl)) {
      return this.pendingRequests.get(requestUrl)!;
    }

    const requestObservable = next.handle(apiRequest)
      .pipe(
        share(),
        catchError((exception: HttpErrorResponse) => this.handleCustomHttpException(exception)),
        finalize(() => this.pendingRequests.delete(requestUrl))
      );

    this.pendingRequests.set(requestUrl, requestObservable);

    return requestObservable;
  }

  handleCustomHttpException(exception: HttpErrorResponse) {
    let errorMessage: string = exception?.error?.message

    if (errorMessage) {
      this.toastr.error(errorMessage);
    }

    return EMPTY;
  }
}
