import axios from 'axios';

export function search(search: string) {
  const url = `https://localhost:5001/Reservation?s=${search}`
  return axios
          .get(url)
          .then((response: any) => response.data);
          // .then(data=> console.log(data));
}