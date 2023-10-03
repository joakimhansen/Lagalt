import React from "react";
import ProjectList from "../components/ProjectList.tsx";
import styled from "styled-components";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronRight } from '@fortawesome/free-solid-svg-icons';

const TopicMenu = styled.div`
    width: 15%;
   
    list-style: none;
    margin-left: 20px;
    margin-top: 20px;
`;

const Wrapper = styled.div`
    display:flex;
`;
const MenuItem = styled.li`
    font-size: 19px;
    padding: 20px;
  
    display:flex;
    justify-content: space-between;
    border-radius: 15px;

    &:hover{
        background-color: #28113e;
    }
`;

const menuItems = [
    {
        title: "Spill"
    },
    {
        title: "Filmer"
    },
    {
        title: "Webutvikling"
    },
];

const HomePage = () => {
    return(
        <Wrapper>
            <TopicMenu>
                {menuItems.map((m) => {
                    return(
                        <MenuItem>
                            {m.title}
                            <FontAwesomeIcon icon={faChevronRight}/>
                        </MenuItem>
                    )
                })}
            </TopicMenu>
            <ProjectList/>
        </Wrapper>
    );
}
export default HomePage;