export interface Forecast {
    Date: Date,
    Icon: number,
    MinimumValue: number,
    MaximumValue: number,
    Unit: string,
    WindSpeed: number, 
    WindUnit: string,
    IconPhrase: string,
    AirQuality: string,
    IsToday: boolean,
    CloudCover: string
}