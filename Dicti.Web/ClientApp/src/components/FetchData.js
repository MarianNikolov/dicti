import React, { Component } from 'react';
import RestServices from '../RestServices/restService';

export class FetchData extends Component {

	constructor(props) {
		super(props);
		this.state = {
			forecasts: null,
			loading: true
		};
	}

	componentDidMount() {
		this.populateWeatherData();
	}

	renderForecastsTable(forecasts) {
		return (
			<table className='table table-striped' aria-labelledby="tabelLabel">
				<thead>
					<tr>
						<th>Date</th>
						<th>Temp. (C)</th>
						<th>Temp. (F)</th>
						<th>Summary</th>
					</tr>
				</thead>
				<tbody>
					{forecasts.map(forecast =>
						<tr key={forecast.date}>
							<td>{forecast.date}</td>
							<td>{forecast.temperatureC}</td>
							<td>{forecast.temperatureF}</td>
							<td>{forecast.summary}</td>
						</tr>
					)}
				</tbody>
			</table>
		);
	}

	render() {

		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: this.state.forecasts && this.renderForecastsTable(this.state.forecasts);

		return (
			<div>
				<h1 id="tabelLabel" >Weather forecast</h1>
				<p>This component demonstrates fetching data from the server.</p>
				{contents}
			</div>
		);
	}

	populateWeatherData() {

		RestServices.get("/weatherforecast")
			.then((forecastData) => {
				this.setState({ forecasts: forecastData.data, loading: false })
			})
			.catch((error) => {
				console.log(error)
			})
	}
}
