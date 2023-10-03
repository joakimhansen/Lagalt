import React from "react";
import styled from "styled-components";

const ProjectListItem = styled.div`
    padding: 20px;
    border-radius: 20px;
    background-color: #28113e;
    width: 50%;
`;

const Wrapper = styled.div`
    width: 100%;
    display:flex;
    margin-left: 20px;
    margin-top: 20px;
`;

const Title = styled.div`
    font-weight: bold;
    margin: 10px 0;
`;
const Description = styled.div`
    color: #d7c1ee;
    margin-bottom: 10px;
    line-height: 1.3;
`;

const ProjectList = () => {
    return(
        <Wrapper>
            <ProjectListItem>
                <Title>Prosjektnavn</Title>
                <Description>Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!</Description>
                <div>Link?</div>
            </ProjectListItem>
        </Wrapper>
    );
}
export default ProjectList;