AppDebug = OpenStruct.new(require?: true) unless defined?(AppDebug)
require_relative './initializers/_'
require_relative './helpers/_'
require_relative './config/_'
require_relative './custom_builders/_'
require_relative './custom_actions/_'
require_relative './initializers/_final'

# build_me # see ./new_builder
option_builder = BuilderOptions
  .init
  .debug(1, me: 1, builder_config: 0, app_settings: 0)
  .create_project(1, create: 1, delete: 0, bootstrap: 0, force: 0, filter_project_name: :reservation_api) # :all
# don't overwrite reservation_domainomain .builders

opts = option_builder.build

CreateProjects.execute(opts.create_project)

option_builder.print                          if opts.debug.me
builder.configuration.debug                   if opts.debug.builder_config
app_print                                     if opts.debug.app_settings

puts ':)'
