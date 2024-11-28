import React, { useState } from "react"
import calculateProbability from "./Service/CalculationService";
import './App.css';

const App = () => {

    const [formData, setFormData] = useState({
        a: 0,
        b: 0
    });

    const [calculationType, setCalculationType] = useState("Combine");

    const [textarea, setTextarea] = useState(
        "The content of a textarea goes in the value attribute"
    );

    const handleChange = (e) => {
        e.target.name == "calculationType" ?
            setCalculationType(e.target.value) :
            setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        calculateProbability(formData, calculationType).then((responseText) => {
            setTextarea(responseText);
        });
       
    };

    return (
        <form onSubmit={handleSubmit}>

            <div className="form_input">
                <input
                    className = "input"
                    type="number"
                    name="a"
                    placeholder="Enter A"
                    value={formData.a}
                    onChange={handleChange}
                />
                <input
                    className="input"
                    type="number"
                    name="b"
                    placeholder="Enter B"
                    value={formData.b}
                    onChange={handleChange}
                />
                <select
                    className="input"
                    name="calculationType"
                    value={formData.calculationType}
                    onChange={handleChange}>
                    <option value="Combine">Combine</option>
                    <option value="Either">Either</option>
                </select>
            </div>
            <div className="form_submit">
                <button type="submit">Submit</button>
            </div>
            <div className="form_output">
                <textarea className="box_output" value={textarea}>asdsa</textarea>
            </div>
        </form>
    );
};

export default App;