import axios from "axios";

const client = axios.create({
    baseURL: "https://localhost:44343/api",
    json: true,
    crossDomain: true,
    withCredentials: false
});

export default {
    async execute(method, resource, data) {
        if ('POST' === method)
            data = {form: data};

        const config = {
            method,
            url: resource,
            data: 'POST' === method ? 'json=' + JSON.stringify(data) : data,
            handlerEnabled: true,
            headers: {
                "Access-Control-Allow-Origin": "http://localhost:8080",
                "Access-Control-Allow-Methods": "GET, POST, OPTIONS, PUT, PATCH, DELETE",
                "Access-Control-Allow-Headers": "Access-Control-Allow-Origin, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers,X-Access-Token,XKey,Authorization",
                'Content-Type': 'application/x-www-form-urlencoded',
            }
        };

        return client(config).then(req => {
            return req.data;
        });
    },

    // *****************************************************************************************************************
    // User
    // *****************************************************************************************************************
    userLogin(data) {
        return this.execute("POST", "/user/login", data);
    },

    userRegister(data) {
        return this.execute("POST", "/user/register", data);
    },

    // *****************************************************************************************************************
    // Artist
    // *****************************************************************************************************************
    artistLogin(data) {
        return this.execute("POST", "/artist/login", data);
    },

    artistRegister(data) {
        return this.execute("POST", "/artist/register", data);
    },

    artistEdit(data) {
        return this.execute("POST", "/artist/edit", data);
    },

    artistRemove(data) {
        return this.execute("DELETE", "/artist/" + data);
    },

    artistFindAll(data) {
        return this.execute("GET", "/artist/" + data);
    },

    artistFindById(managerId, artistId) {
        return this.execute("GET", "/artist/" + managerId + "/" + artistId);
    },

    // *****************************************************************************************************************
    // Manager
    // *****************************************************************************************************************
    managerLogin(data) {
        return this.execute("POST", "/manager/login", data);
    },

    managerRegister(data) {
        return this.execute("POST", "/manager/register", data);
    },

    // *****************************************************************************************************************
    // Album
    // *****************************************************************************************************************
    albumAdd(data) {
        return this.execute("POST", "/album/add", data);
    },

    albumEdit(data) {
        return this.execute("POST", "/album/edit", data);
    },

    albumRemove(data) {
        return this.execute("POST", "/album/remove", data);
    },

    albumFindById(id) {
        return this.execute("GET", "/album/" + id);
    },
    // *****************************************************************************************************************
    // Media
    // *****************************************************************************************************************
    mediaFindById(id) {
        return this.execute("GET", "/media/" + id);
    },

    mediaAdd(data) {
        return this.execute("POST", "/media/add", data);
    },

    mediaEdit(data) {
        return this.execute("POST", "/media/edit", data);
    },

    mediaRemove(data) {
        return this.execute("POST", "/media/remove", data);
    },

    mediaAddReproducedTime(data) {
        return this.execute("POST", "/media/contentReproduced", data);
    },

    setUserMediaRating(data) {
        return this.execute("POST", "/media/setRating", data);
    },

    getUserMediaRating(userId, mediaId) {
        return this.execute("GET", "/media/" + userId + "/" + mediaId);
    }
};