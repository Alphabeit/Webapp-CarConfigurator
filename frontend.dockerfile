# created:    20260419 / alphabeit
# lastupdate: 20260421 / alphabeit

# See also https://blog.devgenius.io/dockerize-your-vue-js-app-a-step-by-step-tutorial-for-seamless-deploymentinstall-vue-cli-globally-07e21d0b542b for ref.



# install Node.js, JavaScript
FROM node:alpine3.22 as build-stage
WORKDIR /app

# Copy the package.json and package-lock.json files to the working directory
COPY ./frontend/package*.json ./

# Install dependencies
RUN npm install
RUN npm install vue-router
RUN npm install vuetify vite-plugin-vuetify

# Copy the rest of the application code to the working directory
COPY ./frontend ./

# Build the Vue.js application for production
RUN npm run build



# Use the official nginx image as the base image for serving the application
FROM nginx:alpine as production-stage

# Copy the built files from the build-stage to the nginx html directory
COPY --from=build-stage /app/dist /usr/share/nginx/html

# Copy custom nginx configuration files
COPY ./frontend/localwebserver/nginx.conf /etc/nginx/nginx.conf
COPY ./frontend/localwebserver/default.conf /etc/nginx/conf.d/default.conf



# Expose port 80
EXPOSE 80

# Set the entry point to the shell script
ENTRYPOINT ["nginx", "-g", "daemon off;"]
