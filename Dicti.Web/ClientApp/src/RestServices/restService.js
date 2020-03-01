import axios from "axios";



class RestService {

    domainUrl;

    constructor() {
        axios.defaults.headers.post['Content-Type'] = 'application/json';
    }

    setDomainUrl = (config) => {
        this.domainUrl = config.apiDomain;
    }

    post = (url, data) => {
        return new Promise((resolve, reject) => {
            axios({
                method: 'post',
                url: this.domainUrl + url,
                data: JSON.stringify(data)
            }).then((data) => {
                resolve(data);
            }).catch((data) => {
                reject(data);
            });
        })

    }

    get = (url, isExternal) => {
        return new Promise((resolve, reject) => {
            axios({
                method: 'get',
                url: isExternal ? url : this.domainUrl + url
            }).then((data) => {
                resolve(data);
            }).catch((data) => {
                reject(data);
            });
        })
    }
}

export default new RestService;