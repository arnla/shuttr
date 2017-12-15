# shuttr
Photography social network concept for CPSC 481

## Authors
- Angela Ranola
- Emilio Alvarez
- Lawrence Nguyen
- Lean Miguel

## Cases/Functions Implemented
- Photos
- Discussions
- User Login/Sign Up 
- Following
- Commenting
- Posting
- Save
- Searching
- User Profile Picture and Biography Updating
- Post Sorting and Filtering
- Notifications
- Photo Downloading
- User Settings
- Log Out

## 1. Quick Start
You can load the shuttr solution found in the source code folder into Visual Studio and run it from there. Once this has been done, it is possible to use the .exe in the bin/Debug folder.

## 2. Photos
To get to the Photos page, click on the 'Photos' button in the top bar. On this page, users can browse through all the photos posted to Shuttr. They can hover the mouse over the photo in order to see more information about it, like the title, caption, when it was posted, the number of comments, etc. Once a photo is clicked, a popup window will open where users can see the post. This popup will include all the information about the photo as well as the comments. The user can also maximize the photo to view it more closely by clicking on the photo inside the popup. If a user is logged in, he/she will be able to leave comments and reply to comments. They will also be able to save the photo, or leave upvotes. Downloading the photo is also possible, and is discussed in point 13 of this README.

## 3. Discussions
To get to the Discussions page, click on the 'Discussions' button in the top bar. On this page, users can browse through all the discussions posted to Shuttr. Users can click on the discussion post, which will open a popup for that post. In this popup, users can read the description and the comments that others have posted in response. If the user is logged in, they will be able to post comments and save the Discussion post.

## 4. User Login/Signup
When a user navigates to Shuttr, they will automatically be taken to the Following page if they are logged in. Otherwise, they will be redirected to the Photos page. If a user would like to login, they must click on the profile picture icon in the top right corner which will give then the option to Login. Here, they can login if they have an account, or sign up to create a new one. There are also multiple prompts asking the user to sign in if they try to interact while not logged in. In these cases, the user is redirected to the login page if they decide to log in, or they can also cancel the prompt.

## 5. Posting
Users who are logged in are able to post photos and discussions to Shuttr. They do this by clicking the blue POST button in the top bar. After clicking on this button they will have the option to post a photo or a discussion. If posting a photo, a user will click on the BROWSE button to select a file from their computer. If the user wishes to change the photo they added, they can click the photo that is currently added and can browse for another photo. They will also add a mandatory title and can add an optional caption. If posting a discussion, a user must include a title and a description of the discussion. When everything is complete, the user can click the Post button. If they decide not to post, they can click on the Cancel button, where they will be asked if they are sure they would like to cancel.

## 6. Following/Unfollowing
Since Shuttr is meant to be a photography social networking site, users are able to follow other users whose posts they like. To follow a user, the user must navigate to that user's profile page. On that page, there will be a button that says "Follow" or "Unfollow". If a user is currently not following the user, they can click on the "Follow" button to add them to that user's posts to the Following page. If they are following the user, they can click on the "Unfollow" button which will remove that user's posts from their Following page. At the moment, Lawrence is the only other user in the system besides the current user. So the user can choose to follow/unfollow Lawrence.

## 7. Commenting
Users who are logged in may participate in discussions on Photo posts and Discussion threads. They can post their own comments or reply to other users' comments. Users are also able to delete or edit the comments that they have posted.

## 8. Saving Posts
Users who are logged in may save photos and discussions. They are able to see these posts by navigating to the Saved page in the top bar. Here, users will see all the photos and discussions that they have saved. This is different from downloading photos because the posts remain inside the Shuttr platform. The posts a user saves are sorted by the time that they saved them, with the newest appearing at the top.

## 9. Searching
If a user would like to see posts that are related to a particular subject, they can type it into the Search bar in the top bar. The search bar will display all photos and discussions that are in any way related to the searched topic. At the moment, the only searchable topic is 'Mountains'. This will return all the photos and discussions related to mountains. If any other topic is searched, it will lead them to a blank results page.

## 10. Editing User Profile
The current user can edit their profile info by navigating to their own profile page. There, they will have the option to change their profile picture and also to change their biography. This is done by clicking on the biography or profile picture.

## 11. Post Sorting/Filtering
Users have multiple choices for sorting the posts on a given page. The sorting option is available on all profile pages, the Discussions page, the Photos page, and the search results page. Users have the option to sort the Photos, profile, and search results pages by Popular, Most commented, Most upvoted and New. In this case, the Popular option refers to the posts with the most upvotes and comments combined. The Discussions page can be sorted only by Most commented and New. In addition to this, users have the option to filter the types of posts shown on profile and search result pages. They can choose between Photos only, Discussions only, or a combination of both.

## 12. Notifications
A user can check their notifications in the top right corner of the top bar by clicking on the bell button. When a user clicks on this, they will see their notifications, with the unopened ones bolded to make them stand out. If a user clicks on a notification, the post pertaining to that notification will open on the screen and the notification will be unhighlighted. At the moment, there is only one hardcoded notification working.

## 13. Photo Downloading
If a user sees a photo that they really like, they are able to download it as long as the original poster has permitted downloads. When posting a photo, a user has the option to make that photo available for download. If they check this option, other users are able to right click on the photo and download it. Otherwise, users will not be able to download the photo.

## 14. User settings
Users with accounts are able to go to the user settings page to change their account settings, namely their email, username, and password. To get to this page, the user must be logged in. They can then click on their profile picture in the top right corner of the top bar and click on User Settings. On this page, users will be able to change their email, username, or password. When finished, and the user would like to save these changes, they must click on MAKE CHANGES, or press enter.The fields that are left blank by the user are not updated.

## 15. Logout
Users who are logging in can log out by clicking on their profile picture in the top right corner of the top bar. After logging out, Shuttr will automatically navigate to the Photos page. The user can no longer make new posts, leave comments, follow users or save posts until they sign back in.