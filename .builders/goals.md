# Goals

## Today

- Rebuild the schema Builder
- Ask for two repositories
  - printspeak-x          - Rails 6 reference application
  - printspeak-domain     # domain schema information
- Build a generator for new project settings
- 
- Watch the videos from Sean Cannel
- Pay for Greenslip and Insurance
  
## Project folders

- Generate a project folder for each of the projects as a sample
- Generate an actual project using the specific types
- What projects do I need today?
  - printspeak-domain `builder`
  - printspeak-react `react`
  - printspeak-react-native `react-native`
  - printspeakx `rails`
  
  - /Users/davidcruwys/dev/csharp/Printspeak `root`
  - Printspeak/Printspeak.Dal `classlib`
  - Printspeak/Printspeak.Dal.Tests `xunit`
  - Printspeak/Printspeak.Web `web`
  - Printspeak/Printspeak.Web.Tests `classlib`
  - Printspeak/Printspeak.Web.UiTests `xunit` + `selenium`
  - 
```bash
bundle gem --coc --test=rspec --mit k_builder-dotnet
bundle gem --coc --test=rspec --mit k_builder-watch
dotnet new web -n P14MovieTheatre -o .
dotnet new mvc -n P15Areas -o .
dotnet new gitignore -o .
rails new . -T -d postgresql --force --webpack=react --skip-git --skip-action-mailer --skip-action-mailbox --skip-action-text
npx create-react-app .
npx expo init .
npx expo init r03-movie-request -t expo-template-blank-typescript
npx expo start
dotnet new mvc -n P15Areas -o .
```

## Project generator

The project generator can create a new type of project.

They will not create the project if it already exists
They can delete a project if needed
The force flag can delete and recreate a project

### Project types

- Builder
- Ruby Gem
- Rails
- React Native
- React
- DotNet
  - There is a list of subtypes
  - 



