import React, { Component } from 'react';
import RestServices from '../RestServices/restService';

export class TranslationsData extends Component {

	constructor(props) {
		super(props);
		this.state = {
			translations: [],
			loading: true
		};
	}

	componentDidMount() {
		this.populateTranslationsData();
	}

	renderTranslationsTable() {
		return (
			<table className='table table-striped' aria-labelledby="tabelLabel">
				<thead>
					<tr>
						<th>From</th>
						<th>Translation</th>
						<th>To</th>
						<th>Translation</th>
					</tr>
				</thead>
				<tbody>
					{this.state.translations && this.state.translations.map(translation =>
						<tr key={translation.id}>
							{translation.transalationValues.map(transalationValue =>
								<React.Fragment key={transalationValue.id}>
									<td>{transalationValue.language.language}</td>
									<td>{transalationValue.text}</td>
								</React.Fragment>
							)}
						</tr>
					)}
				</tbody>
			</table>
		);
	}

	render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: this.renderTranslationsTable();

		return (
			<div>
				<h1 id="tabelLabel" >Translations</h1>
				<p>The list of all translations</p>
				{contents}
			</div>
		);
	}

	populateTranslationsData() {

		RestServices.get("/translations")
			.then((translationsData) => {
				this.setState({ translations: translationsData.data.data, loading: false })
			})
			.catch((error) => {
				console.log(error)
			})
	}
}
