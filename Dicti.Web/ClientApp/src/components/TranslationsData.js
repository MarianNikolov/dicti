import React, { Component } from 'react';

export class TranslationsData extends Component {
  static displayName = TranslationsData.name;

  constructor(props) {
    super(props);
    this.state = { translations: [], loading: true };
  }

  componentDidMount() {
    this.populateTranslationsData();
  }

  static renderTranslationsTable(response) {
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
          {response.data.map(translation => {
            return (

              <tr key={translation.id}>
                {translation.transalationValues.map(transalationValue => {
                  return (
                    <React.Fragment>
                      <td>{transalationValue.language.language}</td>
                      <td>{transalationValue.text}</td>
                    </React.Fragment>
                  );
                })}

              </tr>);
          })
          }
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : TranslationsData.renderTranslationsTable(this.state.translations);

    return (
      <div>
        <h1 id="tabelLabel" >Translations</h1>
        <p>The list of all translations</p>
        {contents}
      </div>
    );
  }

  async populateTranslationsData() {
    const response = await fetch('translations');
    const data = await response.json();
    this.setState({ translations: data, loading: false });
  }
}
