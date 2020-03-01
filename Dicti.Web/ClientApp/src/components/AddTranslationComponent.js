import React from 'react';
import RestService from '../RestServices/restService';

const ENGLISH_LANG_ID = 1;
const BULGARIAN_LANG_ID = 2;

class AddTranslationComponent extends React.Component {

    englishInputField;
    bulgarianInputField;

    state = {
        emptyFieldError: false,
        saveSuccess: false,
        saveError: null
    }

    saveTranslationHandler = () => {
        if (this.englishInputField.value.length > 0 && this.bulgarianInputField.value.length > 0) {
            this.setState({ emptyFieldError: false})
            let translationToAdd = {
                transalationValues: [
                    {
                        languageId: ENGLISH_LANG_ID,
                        text: this.englishInputField.value
                    },
                    {
                        languageId: BULGARIAN_LANG_ID,
                        text: this.bulgarianInputField.value
                    }
                ]
            }

            RestService.post("/translations", translationToAdd)
                .then((response) => {
                    this.setState({ saveSuccess: true })
                })
                .catch((error) => {
                    this.setState({ saveError: error })
                })
        } else {
            this.setState({ emptyFieldError: true })
        }
    }

    render() {
        return <>
            <div className="save-trn-container">
                <div className="save-trn-lang-column">
                    <label>Английски</label>
                    <input type="text" ref={node => this.englishInputField = node} />
                </div>
                <span className="save-trn-dash"></span>
                <div className="save-trn-lang-column">
                    <label>Български</label>
                    <input type="text" ref={node => this.bulgarianInputField = node} />
                </div>
                <button className="save-trn-button" type="submit" onClick={this.saveTranslationHandler}>Запази</button>
            </div>
            {this.state.saveSuccess && <label className="save-trn-success">Translation added successfully :)</label>}
            {this.state.saveError && <label className="save-trn-error">this.state.saveError</label>}
            {this.state.emptyFieldError && <label className="save-trn-error">You must input all the fields</label>}
        </>
    }
}

export default AddTranslationComponent;