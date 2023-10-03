import React from "react";
import styled from "styled-components";

const Title = styled.div`
    font-weight: bold;
    margin: 10px 0;
`;
const Description = styled.div`
    color: #d7c1ee;
    margin-bottom: 10px;
    line-height: 1.3;
`;
const StyledProjectListItem = styled.div`
    padding: 25px;
    border-radius: 20px;
    background-color: #28113e;
    width: 100%;
`;
const Image = styled.img`
    width: 40px;
    height: 40px;
    border-radius: 100%;
`;
const OwnerWrapper = styled.div`
    display: flex;
    align-items: center;
    gap: 10px;
    width: 110px;
    margin-top: 20px;
`;
const Div = styled.div`
    display: flex;
    justify-content: space-between;
    align-items: center;
`;
const Button = styled.button`
    all:unset;
    background-color: #7834bb;
    border-radius: 20px;
    padding: 10px 20px;
    color: white;
    height: fit-content;

    &:hover{
        background-color: #975dd2;
    }
`;


const ProjectListItem = ({title, description, owner, image}) => {
    return(
        <StyledProjectListItem>
            <Title>{title}</Title>
            <Description>{description}</Description>
         
            <Div>
            <OwnerWrapper>
                <Image src={image} alt={`Picture of ${owner}`}/>
                {owner}
            </OwnerWrapper>
                <Button>Gå til prosjekt</Button>
            </Div>
           
        </StyledProjectListItem>
    );
}
export default ProjectListItem;