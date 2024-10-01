import http from 'k6/http';
import { check } from 'k6'

export let options = {
    insecureSkipTLSVerifiy: true,
    duration: '1m',
    vus: 10
};

export default () => {
    const url = 'https://localhost:44375/fast-posts'
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