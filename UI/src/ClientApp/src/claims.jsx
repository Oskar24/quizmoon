const fetchClaims = async () => {

  const response = await fetch("/bff/user", {headers: {"X-CSRF": 1}});
  console.log(response);
}

export { fetchClaims as default }