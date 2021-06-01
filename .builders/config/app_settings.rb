log.kv 'load', 'app_settings' if AppDebug.require?

def app
  @app ||= app_configuration.raw_data_struct
end

def app_print
  log.section_heading 'application settings'
  log.ostruct app
end
# /dev/csharp/Reservations/config/app_settings.rb
# You are to create a React Native App that will allow users to view a list of reservations.
# The app will need to use axios (or a simulated axios call) to get the list of reservations from your API backend.
# The project will need to be made using React Native and implement flex
# layout design to adequately display on any phone dimension.

def app_configuration
  KDoc.model :app do
    s = settings do
      name                          :reservation
      title                         'Reservation'
      description                   'Reservations system allows users to view a list of reservations'
      lib_path                      ''
      namespaces                    ['']
      app_path                      '~/dev/csharp/Reservations'
      git_repo_name                 'reservations'
      git_organization              'klueless-react-samples'
      avatar                        'Restaurant Owner'
      main_story                    'As a Restaurant Owner, I want to view reservations, so that I know what customers are coming today.'
      author                        'David Cruwys'
      author_email                  'david@ideasmen.com.au'
      copyright_date                '2021'
    end

    table :projects do
      # fields :column1, :column2, f(:column3, false), f(:column4, default: 'CUSTOM VALUE')

      fields :name,
            :type,
            :description,
            f(:lib_path, default: s.lib_path),
            f(:namespaces, default: s.namespaces),
            f(:app_path, default: s.app_path),
            f(:git_organization, default: s.git_organization),
            f(:avatar, default: s.avatar),
            f(:main_story, default: s.main_story),
            f(:author, default: s.author),
            f(:author_email, default: s.author_email),
            f(:copyright_date, default: s.copyright_date)

      row :reservation             , :root_folder        , "#{s.title} system allows users to view a list of reservations"

      row :reservation_domain      , :domain_modal       , "#{s.title} domain modal",
          app_path:                 File.join(s.app_path, 'reservation-domain'),
          notes:                    'Domain is a tool that converts the schema.rb into a rich schema by reading in the code and annotating the schema with extra information that is found in the code.',
          new_project_command:      'k_builder-watch -n .'

      row :reservation_api         , :dotnet              , "#{s.title} ASP.net API application",
          database_name:            'reservation',
          database_password:        'SamplePassword',
          app_path:                 File.join(s.app_path, 'ReservationApi'),
          new_project_command:      'dotnet new api -n ReservationApi -o .'

      row :reservation_react_native, :react_native       , "#{s.title} admin UI checking on reservations",
          app_path:                 File.join(s.app_path, 'reservation-react-native'),
          new_project_command:      'npx expo init . -t expo-template-blank-typescript'
    end
  end
end