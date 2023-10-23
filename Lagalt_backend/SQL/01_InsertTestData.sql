USE [LagaltDB]

INSERT INTO [User]
VALUES ('john_doe', 'John Doe is a software developer with a passion for open-source projects.', 'https://randomuser.me/api/portraits/men/44.jpg', 0),
    ('sarah_smith', 'Sarah Smith is a musician and composer specializing in jazz and electronic music.', 'https://randomuser.me/api/portraits/women/77.jpg', 0),
    ('emily_wong', 'Emily Wong is a filmmaker and director known for her short documentaries.', 'https://randomuser.me/api/portraits/women/57.jpg', 1),
    ('michael_jackson', 'Michael Jackson is a professional gamer and Twitch streamer.', 'https://randomuser.me/api/portraits/men/67.jpg', 0),
    ('linda_davis', 'Linda Davis is a web developer with expertise in front-end technologies.', 'https://randomuser.me/api/portraits/women/80.jpg', 1),
    ('magnusuttisrud', 'Test1', 'https://randomuser.me/api/portraits/men/73.jpg', 0),
    ('joakimskaalevik', 'Test2', 'https://randomuser.me/api/portraits/men/40.jpg', 0),
    ('siljedenise', 'Test2', 'https://randomuser.me/api/portraits/women/75.jpg', 0),
    ('siljeslettebakk', 'Test4', 'https://randomuser.me/api/portraits/women/81.jpg', 0),
    ('jessica_jones', 'Jessica Jones is a full-stack developer specializing in web applications.', 'https://randomuser.me/api/portraits/women/11.jpg', 0),
    ('david_lee', 'David Lee is a software architect with a passion for scalable systems.', 'https://randomuser.me/api/portraits/men/22.jpg', 0),
    ('lucas_wilson', 'Lucas Wilson is a software developer with experience in mobile app development.', 'https://randomuser.me/api/portraits/men/33.jpg', 0),
    ('andrew_smith', 'Andrew Smith is a software engineer with expertise in backend development.', 'https://randomuser.me/api/portraits/men/44.jpg', 0);


INSERT INTO [Skill]
VALUES ('Frontend')
,('Backend')
,('Fullstack')
,('HTML')
,('CSS')
,('JavaScript')
,('UI/UX Design')
,('Music Composition')
,('Film Editing');


INSERT INTO [UserSkillLink]
VALUES ('john_doe', '4')
,('linda_davis', '4')
,('john_doe', '5')
,('linda_davis', '5')
,('john_doe', '6')
,('john_doe', '7')
,('sarah_smith', '7')
,('sarah_smith', '8')
,('emily_wong', '9')
,('magnusuttisrud', '8')
,('magnusuttisrud', '9')
,('joakimskaalevik', '8')
,('joakimskaalevik', '9')
,('siljedenise', '7')
,('siljedenise', '9')
,('siljeslettebakk', '7')
,('siljeslettebakk', '9')
,('jessica_jones', '5')
,('jessica_jones', '7')
,('david_lee', '4')
,('david_lee', '6')
,('lucas_wilson', '8')
,('lucas_wilson', '9')
,('andrew_smith', '5')
,('andrew_smith', '6');


INSERT INTO [Category]
VALUES ('Software development')
,('Music')
,('Film')
,('Gaming')


INSERT INTO [Project] ([Title], [Short_Description], [Full_Description], [Github_Url], [Progress], [Category_Id], [Creator_Name])
    VALUES ('E-commerce Website Revamp', 'Revamp an e-commerce website for a seamless shopping experience.', 'Calling all web developers and UI/UX designers! We are revamping an e-commerce website to provide shoppers with a better and smoother experience. Join our team to work on frontend and backend development, as well as enhancing the user interface. Lets make online shopping a breeze!', 'http://github.com/ecommerce/revamp', 2, 1, 'siljeslettebakk')
     ,('Mobile App Development - Fitness Tracker', 'Create a fitness tracking app to help users stay healthy.', 'Fitness enthusiasts and app developers, this project is for you! We are developing a mobile app that tracks users workouts, nutrition, and progress. If you have skills in mobile app development, UI design, or fitness training, join us and help people lead healthier lives.', 'http://github.com/fitnessapp/tracker', 1, 1, 'john_doe')
     ,('Music Production - Electronic Dance', 'Join the electronic dance music production crew!', 'Electronic dance music lovers, unite! We are producing an EDM track and looking for DJs, producers, and sound engineers to collaborate on this high-energy project. Lets create a dancefloor anthem that gets the crowd moving!', 'http://github.com/musicproduction/edm', 2, 2, 'sarah_smith')
     ,('Documentary - Environmental Conservation', 'Spread awareness through a documentary on conservation efforts.', 'Calling all documentary filmmakers! We are working on a documentary that highlights environmental conservation initiatives. If you are passionate about nature and storytelling, join our team as a director, editor, or researcher and help us raise awareness for a greener planet.', 'http://github.com/filmproject/environment', 1, 3, 'emily_wong')
     ,('Game dev - PuzzleAdventure', 'Solve puzzles and embark on an epic adventure in this mobile game.', 'Game developers, get ready to create an addictive puzzle adventure game for mobile devices. We need game designers, level creators, and artists to bring this exciting world to life. Join us and challenge players minds with mind-bending puzzles!', 'http://github.com/gamedev/puzzleadventure', 0, 4, 'michael_jackson')
     ,('Web App for Music Enthusiasts', 'Build a web app for music discovery and playlists.', 'Web developers and music aficionados, come together to build a music discovery platform! We are creating a web app where users can discover new music, create playlists, and share their favorite tracks. If you have skills in web development, databases, or music curation, lets make music exploration fun and easy!', 'http://github.com/musicapp/discovery', 1, 1, 'linda_davis')
    ,('Space-themed Video Game - Strategy', 'Command your space fleet in this epic strategy game!', 'Game developers, space enthusiasts, and strategy gamers, this project is out of this world! We are developing a space-themed strategy game where you can command your own fleet and explore the cosmos. Join us as a game designer, coder, or artist, and lets conquer the universe!', 'http://github.com/gamedev/spacestrategy', 2, 4, 'michael_jackson')
	,('Music Collaboration - Jazz Fusion', 'Join us for a jazz fusion music collaboration project!', 'Calling all jazz musicians and composers! We are working on an exciting jazz fusion album and looking for talented musicians to collaborate with. Whether you play the saxophone, piano, drums, or any other instrument, we will love to have you on board. Lets create some smooth jazz magic together.', 'http://github.com/musiccollab/jazzfusion', 1, 2, 'sarah_smith')
    ,('Short Film Production - Mystery Genre', 'Be a part of our suspenseful mystery film project.', 'Are you a filmmaker with a passion for mystery and suspense? Join our team to produce an intriguing short film in the mystery genre. We need directors, screenwriters, actors, and cinematographers to bring this thrilling story to life. Let your creativity shine!', 'http://github.com/filmproject/mystery', 0, 3, 'emily_wong')
    ,('Game Development - RPG Adventure', 'Embark on a journey to create an epic RPG adventure game!', 'Game developers and designers, unite! We are on a quest to develop an immersive RPG adventure game filled with quests, dungeons, and epic battles. If you have experience in game design, coding, or 3D modeling, join our guild and help us craft a legendary gaming experience.', 'http://github.com/gamedev/rpgadventure', 1, 4, 'siljeslettebakk')
    ,('Real-Time Chat Application', 'Develop a real-time chat application for seamless communication.', 'Are you a fan of real-time communication? We are building a real-time chat application that will allow users to connect instantly. Join our team of developers to work on messaging features, push notifications, and chat rooms. Letss create a chat app that keeps people connected!', 'http://github.com/chatapp/realtime', 0, 1, 'jessica_jones')
    ,('Cloud-Based File Storage', 'Create a cloud-based file storage solution for secure data management.', 'Join us in building a cloud-based file storage platform that ensures data security and accessibility. We need backend developers, cloud experts, and encryption specialists to contribute to this project. Lets make data storage easy and safe!', 'http://github.com/storage/cloudfile', 2, 1, 'david_lee')
    ,('Mobile App for Event Management', 'Develop a mobile app for organizing and managing events.', 'Event enthusiasts, unite! We are creating a mobile app that simplifies event planning, ticketing, and coordination. If you have skills in mobile app development, UI/UX design, or event management, join us and make event organization a breeze!', 'http://github.com/eventapp/management', 1, 1, 'lucas_wilson')
    ,('Social Media Analytics Dashboard', 'Build a dashboard for analyzing social media data.', 'Data analysts and web developers, we need your expertise to create a social media analytics dashboard. Join our team to work on data visualization, data mining, and user-friendly dashboards. Lets uncover insights from the world of social media!', 'http://github.com/analytics/socialmedia', 0, 1, 'andrew_smith')
    ,('E-Learning Platform Expansion', 'Expand an e-learning platform with new courses and features.', 'Join us in expanding our e-learning platform by adding new courses and interactive features. We need educators, content creators, and web developers to help us provide quality education online. Lets make learning accessible to all!', 'http://github.com/elearning/expansion', 1, 1, 'jessica_jones')
    ,('Task Management App - Team Collaboration', 'Create a task management app for efficient team collaboration.', 'Team leaders and app developers, this one is for you! We are building a task management app to help teams collaborate more effectively. If you have skills in mobile app development, task management, or team collaboration, join us and boost productivity!', 'http://github.com/taskapp/collaboration', 2, 1, 'david_lee')
    ,('E-Commerce Analytics Tool', 'Develop an analytics tool for e-commerce businesses.', 'Help e-commerce businesses thrive with a dedicated analytics tool. We are looking for data scientists, front-end developers, and e-commerce experts to create a powerful analytics platform. Lets drive success for online retailers!', 'http://github.com/ecommerce/analytics', 0, 1, 'lucas_wilson')
    ,('AI Chatbot for Customer Support', 'Build an AI chatbot for automated customer support.', 'Enhance customer support with an AI chatbot that can handle customer inquiries. If you have experience in AI development, chatbot design, or customer service, join us and make customer support more efficient!', 'http://github.com/chatbot/support', 1, 1, 'andrew_smith')
    ,('Online Code Collaboration Platform', 'Create a platform for collaborative coding and development.', 'Calling all coders and developers! We are building an online platform that allows developers to collaborate on coding projects in real-time. Join us as a full-stack developer, coder, or UI/UX designer, and lets revolutionize the way developers work together!', 'http://github.com/collab/codeplatform', 2, 1, 'jessica_jones');



INSERT INTO [CollaboratorApplication]
VALUES
('I have extensive experience in web development and can contribute to the e-commerce website revamp project. Looking forward to working with the team!', 'linda_davis', 1)
,('I am a jazz pianist with a strong background in music composition. I will love to collaborate on the jazz fusion music project!', 'sarah_smith', 8)
,('I am passionate about fitness and mobile app development. I will like to help create the fitness tracker app. Lets make it a success!', 'john_doe', 2)
,('I am a puzzle game enthusiast with a knack for level design. Count me in for the mobile game development project!', 'michael_jackson', 5)
,('I am a film editor with a love for environmental conservation. I will be honored to work on the documentary film project.', 'emily_wong', 4)
,('I have a deep interest in electronic dance music and sound engineering. Lets create some high-energy EDM together!', 'sarah_smith', 3);


INSERT INTO [ProjectCollaboratorLink]
VALUES (1, 'magnusuttisrud')
,(5, 'magnusuttisrud')
,(2, 'joakimskaalevik')
,(6, 'joakimskaalevik')
,(3, 'siljedenise')
,(7, 'siljedenise')
,(4, 'siljeslettebakk')
,(8, 'siljeslettebakk');



INSERT INTO [ProjectSkillLink]
VALUES (1, 1)
,(1, 2)
,(1, 3)
,(1, 4)
,(2, 4)
,(2, 8)
,(3, 5)
,(4, 6)
,(5, 4)
,(5, 7)
,(5, 8)
,(5, 9)
,(6, 3)
,(6, 7)
,(6, 8)
,(6, 9)
,(7, 4)
,(7, 6)
,(7, 7)
,(7, 8)
,(8, 5)
,(9, 6)
,(10, 4)
,(10, 7)
,(10, 8)
,(10, 9);