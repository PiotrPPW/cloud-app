FROM node:20-alpine
WORKDIR /app
COPY . .
RUN echo "Frontend placeholder"
EXPOSE 80
CMD ["node", "-e", "require('http').createServer((req,res)=>res.end('Frontend OK')).listen(80)"]