import config from "../Config/Config.json";



async function calculateProbability(formData, calculationType) {
    var BASEURL = config.BASEURL;

    try {
        const url = (calculationType == "Combine" ? BASEURL + "Combine?" :
            BASEURL + "Either?") +
            new URLSearchParams(formData)


        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            cache: 'no-store' 
        }).catch((error) => console.log(error));

        let responseText = await response.text();
        if (responseText == "") { console.log(response) }
        return responseText
    }
    catch (error) {
        console.error('Fetch error:', error);
    }

}

export default calculateProbability;