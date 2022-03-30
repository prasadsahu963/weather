import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import {
  tap,
  debounceTime,
  distinctUntilChanged,
  concatMap,
} from 'rxjs/operators';
import { Location } from './models/Location';
import { Forecast } from './models/Forecast';
import { WeatherForecastService } from './services/weather-forecast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent implements OnInit, OnDestroy {
  title = 'Weather App';
  locationSub$: Subscription = new Subscription();
  options: Location[] = [];
  locationAutoCompleteControl = new FormControl();
  locationForecasts: Forecast[] = [];
  index = 0;
  currentDate = new Date();
  selectedLocation: string = '';
  constructor(private weatherForecastService: WeatherForecastService) {}

  locations$: Subscription = new Subscription();
  
  ngOnInit() {
    this.locationSub$ = this.weatherForecastService
                        .getWeatherForLocation('347628')
                        .subscribe(x => {
                          this.setForecasts(x);
                        });

    this.locations$ = this.locationAutoCompleteControl.valueChanges
      .pipe(
        debounceTime(500),
        distinctUntilChanged(),
        concatMap((name) => (name) ? this.weatherForecastService.getLocationsBySearchTerm(name.split(',')[0]): this.options = []),
        tap((data) => {
          if(data.length != 0)
            this.options = data.map((value: any)=>{ 
              return  { key: value?.key, localizedName: `${value.localizedName}, ${value?.administrativeArea?.localizedName}, ${value?.country?.localizedName}`}
            })
        })
      )
      .subscribe();
  }

  displayForecast(value: string) {
    this.selectedLocation = value.split(',')[0];

    const selectedLocation: Location[] = this.options.filter(
      (option) => option.localizedName === value
    );
    
    this.locationSub$ = this.weatherForecastService
                        .getWeatherForLocation(selectedLocation[0].key)
                        .subscribe(x => {
                          this.setForecasts(x);
                        });
  }

  setDay(i: number){
    this.index = i;
  }
   setForecasts(data: any[]){
    console.log('data=>', data);
    this.locationForecasts = data.map(x => {
      return {
        Date: x.forecastDate,
        Icon: x?.forecastDetail?.icon,
        MinimumValue: x?.temperature?.minValue,
        MaximumValue: x?.temperature?.maxValue,
        Unit: x?.temperature?.unitMeasure?.unit,
        WindSpeed: x?.forecastDetail?.windSpeed, 
        WindUnit: x?.forecastDetail?.windSpeedUnit?.unit,
        IconPhrase: x?.forecastDetail?.iconPhrase,
        AirQuality: x?.airQuality,
        IsToday: x?.isToday,
        CloudCover: x?.forecastDetail?.cloudCover
      }
    });
    
  }

  ngOnDestroy() {
    this.locationSub$.unsubscribe();
    this.locations$.unsubscribe();
  }
}

