import http from 'k6/http';
import { check } from 'k6'

export let options = {
    insecureSkipTLSVerifiy: true,
    duration: '1m',
    vus: 50
};

export default () => {
    const url = 'http://localhost:51613/posts'
    const payload = JSON.stringify({
        title: "Test Post",
        content: "This is a post"
    });

    const params = {
        headers: {
            'Content-Type': 'application/json'
        }
    }

    const res = http.post(url, payload, params);

    check(res, {
        'is status 400': (r) => r.status === 400
    })
};