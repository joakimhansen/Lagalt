import React from "react";
import styled from "styled-components";

const ProfileInfoWrapper = styled.div`
    background-color: #28113e;
    width: 300px;
    height: 100px;
    padding-left: 50px;
    padding-top: 40px;
    margin: 20px;
    border-radius: 10px;
    list-style: none;

    p {
        text-decoration: none;
        color: white;
        position: relative;
        left: 100px;
        bottom: 62px;
        font-size: 20px;
      }
`;

const Image = styled.img`
    width: 60px;
    height: auto;
    padding-left: ;
`

const test= [
    {
        name: "Silje D",
        about: "Frontend utvikler med en bachelorgrad innen Frontend fra Høyskolen Kristiania",
        skills: ["React", "JavaScript", "TypeScript", ".NET", "Angular"],
    },
    {
        name: "Silje",
        about: "Infoviter med en bachelorgrad innen Informasjonsvitenskap fra Univeristetet i Bergen",
        skills: ["React", "JavaScript", "TypeScript", ".NET"],
    },
];

const UserInfo = () => {
    return(
        <ProfileInfoWrapper>
            <Image src="./../assets/default-profile-picture.png" alt="Default profile picture"/>
            <p>Silje Slettebakk</p>
        </ProfileInfoWrapper>
    );
};
export default UserInfo;