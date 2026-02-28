FROM node:20-alpine
WORKDIR /app
COPY . .
RUN echo "Backend placeholder"
EXPOSE 3000
CMD ["node", "-e", "require('http').createServer((req,res)=>res.end('Backend OK')).listen(3000)"]