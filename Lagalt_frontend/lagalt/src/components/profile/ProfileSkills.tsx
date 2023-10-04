import React from "react";
import styled from "styled-components";

const SkillsWrapper = styled.div`
    background-color: #28113e;
    width: 300px;
    height: 300px;
    padding-left: 50px;
    padding-top: 10px;
    margin: 20px;
    border-radius: 10px;
    list-style: none;

    h2{
        color: white;
    }

    p {
        color: white;
    }
`;

const SkillsHeader = styled.h2`
    font-size: 15px;
`

const Skills = () => {
    return(
        <SkillsWrapper>
            <li>
                <SkillsHeader>
                    <h2>Mine skills:</h2>
                </SkillsHeader>
                <p>JavaScript</p>
                <p>C#</p>
                <p>.NET</p>
                <p>React</p>
            </li>
        </SkillsWrapper>
    );
};
export default Skills;