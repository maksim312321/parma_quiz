<template>
    <div class="container container__main-page">
        <div v-if="infoBlocks">
            <div class="block-info__button"
                 v-for="infoBlock in infoBlocks"
                 :key="infoBlock.id"
                 @click="selectedInfoBlock = infoBlock">
                {{ infoBlock.title }}
            </div>
        </div>
        <div>
            <div v-if="selectedInfoBlock">
                <h3>{{ selectedInfoBlock.subtitle }}</h3>

                <span style="white-space: break-spaces;" v-text="selectedInfoBlock.content"></span>
            </div>
            <div v-else>
                Квест-тур PARMA Technologies Group
            </div>
        </div>
        <div>
            <h3>Ваш результат: {{this.resultsInfo.correctAnswers}} / {{this.questionsCount}}</h3>
            <h3>На проверке: {{this.resultsInfo.reviewAnswers}}</h3>
            <router-link to="/quiz">
                <van-button color="#EC1C24" type="primary">Начать опрос</van-button>
            </router-link>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                infoBlocks: null,
                selectedInfoBlock: null,
                questionsCount: null,
                resultsInfo: {},
            };
        },
        created() {
            this.infoBlocks = JSON.parse('[{"title":"Коротко о компании","subtitle":"Parma TG – ИТ-компания, занимаемся разработкой заказного программного обеспечения для органов государственной власти и коммерческого сектора.","content":"Компания образована в 2016 году Овчаровым Евгением Борисовичем.\\nСейчас на данный момент у нас реализовано более 100 проектов и более 65 информационных систем с использованием различных технологий.\\nКроме разработки ПО также предоставляем услуги внедрения и сопровождения, обучения пользователей системы и услуги тех поддержки.\\nВ нашей компании работает около 630 сотрудников по всей России, как удаленно, так и в офисах.\\nУ нас 2 офиса: пермский - головной и московский.\\nСтруктуру компании - матричная структура, т.е. основана на двойном подчинение.","id":0},{"title":"Инструкция по работе в Microsoft Teams","subtitle":"Microsoft Teams — единое рабочее пространство для команды проекта, которое предоставляет собой современный разговорный интерфейс, позволяющий проводить голосовые и видеоконференции.","content":"Для работы с Microsoft Teams необходимо использовать веб-версию системы доступную по адресу: https://teams.microsoft.com либо установить приложение, доступное для скачивания по ссылке.\\nЗатем необходимо ввести логин и пароль доменной учетной записи (@parmalogica.ru).\\nКоманда в Microsoft Teams - групповой чат, позволяющий вести групповую переписку, проводить голосовые и видеоконференции, а также осуществлять совместную работу с документами.\\nДля создания доступно два вида команд:\\nОбщедоступные - доступны всем сотрудникам Компании.\\nКонфиденциальные - доступны только сотрудникам добавленным в данную команду.","id":1},{"title":"Получение техники и мебели домой","subtitle":"Да, можно, но нужно обоснование.","content":"1. Приготовь паспорт, мобилу, договор.\\n\\n2. Заполни акт. Укажи ВСЁ что нужно взять.\\n\\n3. Отправь заявку на techsupport@parma.ru с указанием:\\n\\n- требуется ли вам помощь в доставке техники домой;\\n\\n- требуется ли вам помощь в подключении техники;\\n\\n- требуются ли вам канцтовары.\\n\\nЕсли у вас что-то сломалось, то следует написать в Тех поддержку.","id":2},{"title":"Отдел взаимодействия с учебными заведениями","subtitle":"НАШИ ЗАДАЧИ:","content":"● Взаимодействие с вузами (также с нами нужно согласовывать все отчеты перед отправкой учебным заведениям)\\n● Формирование внутреннего, внешнего HR бренда\\n● Мотивация персонала\\n\\nПрактика - применение навыков и умений студента, полученных в вузе, на производственных задачах Компании.\\n- Требования к кандидату: базовые знания и навыки (специфичные знания и навыки не требуются)\\n- Срок привлечения: от 2 недель до несколько месяцев\\n- Не оплачивается\\n\\nСтажировка - комплекс мероприятий в Компании, направленный получение стажерами знаний, умений и навыков, необходимых для последующего трудоустройства в Компанию на постоянной основе.\\n- Требования к кандидату: требования, предъявляемые структурным подразделением к личным, профессиональным качествам и компетенциям\\n- Срок привлечения: 3 месяца\\n- Оплачивается\\n\\nПроектная деятельность - особый вид групповой практики у студентов.\\n- Цель – показать, как устроена внутренняя кухня Компании, научиться работать в командах и правильно коммуницировать с заказчиком (заказчик=мы).\\n\\n- Наша задача:\\nЗнакомство с компанией (презентация+экскурсия)\\nПроведение раз в неделю МК (госты, жизненный цикл проектов, правила деловой переписки или любой другой на выбор)\\nВыполняем роль заказчика: согласуем ТЗ, макеты, сам проект, проводим итоговую защиту проекта, оцениваем результат работы команды","id":3}]')
            this.selectedInfoBlock = this.infoBlocks[0];
            this.loadResults();
        },
        methods: {
            async loadResults() {
                const user = JSON.parse(window.getCookie('user'));
                let res;
                await fetch('https://localhost:7202/question/all')
                    .then(response => response.json())
                    .then(response => { res = response });
                this.questionsCount = res.length;

                try {
                    await fetch(`https://localhost:7202/api/userAnswers/${user.id}`)
                        .then(response => response.json())
                        .then(response => { res = response });
                }
                catch (e) {
                    console.log(e);
                }

                this.resultsInfo.correctAnswers = 0;
                this.resultsInfo.reviewAnswers = 0;

                res.forEach(item => {
                    if (item.isCorrect) {
                        this.resultsInfo.correctAnswers++;
                    }
                    if (item.isCorrect === null) {
                        this.resultsInfo.reviewAnswers++;
                    }
                });
            }
        },
    });
</script>

<style>
    .container {
        width: 80%;
        margin: 0 auto;
        margin-top: 80px;
    }

    .container__main-page {
        width: 80%;
        margin: 0 auto;
        display: grid;
        grid-template-columns: 20% 50% 30%;
        grid-gap: 30px;
        margin-top: 80px;
    }

    .block-info__button {
        background: #E9ECEE;
        text-align: center;
        cursor: pointer;
        font-family: 'Montserrat';
        font-weight: 800;
        padding: 13px;
        margin-top: 11px;
    }

    .block-info__button:first-child {
        margin-top: 0;
    }
</style>