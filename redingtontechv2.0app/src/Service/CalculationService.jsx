import config from "../Config/Config.json";

async function calculateProbability(formData, calculationType) {

    const url = (calculationType == "Combine" ? config.BASEURL + "Combine?" :
        config.BASEURL + "Either?") +
        new URLSearchParams(formData)

    let response = await fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
    let responseText = await response.text();
    return responseText

}

export default calculateProbability;