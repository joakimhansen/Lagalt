import React from "react";
import styled from "styled-components";

const SkillsWrapper = styled.div`
    background-color: #28113e;
    width: 300px;
    height: 300px;
    padding-left: 50px;
    padding-top: 10px;
    border-radius: 20px;
    list-style: none;
    margin-top: 20px;

    h2{
        color: #e7daf5;
    }

    li{
        line-height: 35px;
    }
`;

// const SkillsButton = styled.button`
//     background-color: #7834bb;
//     border: none;
//     color: #e7daf5;
//     font-size: 16px;
//     border-radius: 20px;
//     padding: 10px 15px;
//     margin-left: 190px;
//     height: fit-content;

//     &:hover{
//         background-color: #975dd2;
//     }
// `;

const Skills = () => {

    const tests = [
        {skills: "React"}, 
        {skills: "JavaScript"},
        {skills: "TypeScript"},
        {skills: ".NET"},
        {skills: "Angular"}
    ]

    return (
        <ul>
            <SkillsWrapper>
                <h2>Mine skills:</h2>
                {tests.map((item, index) => {
                    if (item.skills) {
                        return(
                            <li key={index}>{item.skills}</li>
                        )
                    }
                })}
                {/* <SkillsButton>Add skill</SkillsButton> */}
            </SkillsWrapper>
        </ul>
    );
};
export default Skills;